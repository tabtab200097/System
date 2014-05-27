using System;
using System.Collections.Generic;
using System.Text;

namespace JsonModel
{
    /// <summary>
    /// Класс для авторизации
    /// </summary>
    public class AuthRequest
    {
        public string login { get; set; }
        public string password { get; set; }
    }
    // тест

    public class GeneralRequest
    {
        public int token { get; set; }
    }


    public class RequestTest:GeneralRequest
    {
        public int id { get; set; }
    }
    public class JsonQuestion
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public List<JsonAnswer> answers { get; set; }
    }
    public class JsonAnswer
    {
        public int id { get; set; }
        public string content { get; set; }

    }
    public class JsonTest
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<JsonQuestion> questions { get; set; }

    }
}
