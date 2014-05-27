using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using JsonModel;
using Newtonsoft.Json;
using Server.DB;
using System.Diagnostics;

namespace Server
{
    public partial class  Client
    {
        //TODO посмотри
        /// <summary>
        /// Функция возращает тест с вариантами ответов и вопросами
        /// написана но н епроверена, бд пуста
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="bytesRec"></param>
        /// <returns></returns>
        private byte[] getTest(byte[] bytes, int bytesRec)
        {
            //int bytesRec = this.stream.Receive(this.bytes);
            string json = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            RequestTest data = new RequestTest();
            data = JsonConvert.DeserializeObject<RequestTest>(json);

            JsonTest resultTest = null;
            
            Test test = DB.Test.Where(x => x.Id == data.id).FirstOrDefault();
            if (test != null)
            {
                resultTest = new JsonTest();

                resultTest.name = test.Name;
                resultTest.id = test.Id;
                var questions = test.QUESTION.ToList();
                List<JsonQuestion> resultQuestion = new List<JsonQuestion>(); 
                foreach( Question t  in questions)
                {
                    JsonQuestion qu = new JsonQuestion();
                    qu.id = t.Id;
                    qu.title = t.Title;
                    qu.content = t.Content;
                    var answers = t.ANSWER.ToList();
                    List<JsonAnswer> resultAnswer = new List<JsonAnswer>();
                    foreach (Answer a in answers)
                    {
                        JsonAnswer answer = new JsonAnswer();
                        answer.content = a.Content;
                        answer.id = a.Id;
                        resultAnswer.Add(answer);
                    }
                    qu.answers = resultAnswer;
                    resultQuestion.Add(qu);
                }
                resultTest.questions = resultQuestion;
            }

            string response = JsonConvert.SerializeObject(resultTest);


            byte[] msg = Encoding.UTF8.GetBytes(response);
            return msg;
        }
    }
}
