using FlagQuizWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlagQuizWebApp.Models
{
    public class Question
    {
        public Question(Flag flag, FlagRepository repository)
        {
            this.Id = flag.Id;

            this.Options = new List<string>();

            this.Options.Add(flag.Name);

            while (this.Options.Count < 4)
            {
                Flag option = GetRandomFlag(repository);
                if (!this.Options.Contains(option.Name))
                {
                    this.Options.Add(option.Name);
                }
            }            

            this.Options.Sort();
        }

        private Flag GetRandomFlag(FlagRepository repository)
        {
            Random r = new Random();

            int opt = r.Next(1, 10);

            while (opt == this.Id)
            {
                opt = r.Next(1, 10);
            }

            return repository.GetFlag(opt);
        }

        public int Id { get; set; }

        public List<string> Options { get; set; }
    }
}