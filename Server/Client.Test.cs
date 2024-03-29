﻿using System;
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
    public partial class Client
    {

        private byte[] SendTestById(byte[] bytes)
        {
            //string json = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            //RequestTest data = new RequestTest();
            //data = JsonConvert.DeserializeObject<RequestTest>(json);

            int temp = BitConverter.ToInt32(bytes, 0);

            JsonTest resultTest = null;

            Test test = DB.Test.Where(x => x.Id == temp).FirstOrDefault();
            if (test != null)
            {
                resultTest = new JsonTest();

                resultTest.name = test.Name;
                resultTest.id = test.Id;
                var questions = test.QUESTION.ToList();
                List<JsonQuestion> resultQuestion = new List<JsonQuestion>();
                foreach (Question t in questions)
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

        private byte[] SendTestList()
        {
            var result = DB.Test.Select(x => new { id = x.Id, name = x.Name }).ToList();

            string response = JsonConvert.SerializeObject(result);


            byte[] msg = Encoding.UTF8.GetBytes(response);
            return msg;

        }

        private byte[] CheckMyAnswersPleeease(byte[] bytes)
        {
            string tempjson = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            JsonUserTest userresult = JsonConvert.DeserializeObject<JsonUserTest>(tempjson);

            List<JsonUserResult> list = new List<JsonUserResult>();
            foreach (JsonUserQuestion t in userresult.questions)
            {
                JsonUserResult result = new JsonUserResult();
                //result.questionid = t.questionid;
                Question question = DB.Question.Where(x => x.Id == t.questionid).FirstOrDefault();
                result.questionid = question.Id;
                result.title = question.Title;
                result.questioncontent = question.Content;
                int procent_of_result = 0;


                foreach (JsonUserAnswer t2 in t.answers)
                {
                    Answer answer = DB.Answer.Where(x => x.Id == t2.answerid).FirstOrDefault();
                    if (answer != null)
                        if (answer.IsRight==1)
                            procent_of_result++;
                    JsonUserResultAnswer temp_answer = new JsonUserResultAnswer();
                    temp_answer.answer=answer.Content;
                    result.answers.Add(temp_answer);
                }
                result.result = procent_of_result.ToString();

                list.Add(result);
            }
            string response = JsonConvert.SerializeObject(list);
            byte[] msg = Encoding.UTF8.GetBytes(response);
            return msg;
        }


    }
}
