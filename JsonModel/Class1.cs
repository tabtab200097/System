using System;
using System.Collections.Generic;
using System.Text;

namespace JsonModel
{

    public class AuthRequest
    {
        public string login { get; set; }
        public string password { get; set; }
    }

    public class GeneralRequest
    {
        public int token { get; set; }
    }

    public class RequestTest
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

    public class JsonTestList
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class JsonUserAnswer
    {
        public int answerid { get; set; }
    }

    public class JsonUserQuestion
    {
        public int questionid { get; set; }
        public List<JsonUserAnswer> answers { get; set; }
    }

    public class JsonUserTest
    {
        public int id { get; set; }
        public List<JsonUserQuestion> questions { get; set; }
    }

    public class JsonUserResultAnswer
    {
        public string answer { get; set; }
    }
    
    public class JsonUserResult
    {
        public int questionid { get; set; }
        public string title { get; set; }
        public string questioncontent { get; set; }
        public List<JsonUserResultAnswer> answers { get; set; }
        public string result { get; set; }

    }

}
