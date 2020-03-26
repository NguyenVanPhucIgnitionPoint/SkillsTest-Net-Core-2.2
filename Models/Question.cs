using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsTest.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
        public string SelectedAnswer { set; get; }
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
