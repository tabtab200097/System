//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public Question()
        {
            this.ANSWER = new HashSet<Answer>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int TestId { get; set; }
    
        public virtual ICollection<Answer> ANSWER { get; set; }
        public virtual Test TEST { get; set; }
    }
}
