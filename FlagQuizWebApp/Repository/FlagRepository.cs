using FlagQuizWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlagQuizWebApp.Repository
{
    public class FlagRepository
    {
        private List<Flag> _Flags;

        public FlagRepository ()
        {
            this._Flags = new List<Flag>() {
                new Flag()
                {
                    Id = 1
                    , Name = "Brasil"
                    , Ratio = 1
                }
                , new Flag()
                {
                    Id = 2
                    , Name = "Estados Unidos"
                    , Ratio = 1
                }
                , new Flag()
                {
                    Id = 3
                    , Name = "França"
                    , Ratio = 3
                }
                , new Flag()
                {
                    Id = 4
                    , Name = "Alemanha"
                    , Ratio = 5
                }
                , new Flag()
                {
                    Id = 5
                    , Name = "Itália"
                    , Ratio = 3
                }
                , new Flag()
                {
                    Id = 6
                    , Name = "Ilhas Cook"
                    , Ratio = 5
                }
                , new Flag()
                {
                    Id = 7
                    , Name = "Austrália"
                    , Ratio = 4
                }
                , new Flag()
                {
                    Id = 8
                    , Name = "Japão"
                    , Ratio = 4
                }
                , new Flag()
                {
                    Id = 9
                    , Name = "Reino Unido"
                    , Ratio = 2
                }
                , new Flag()
                {
                    Id = 10
                    , Name = "Canadá"
                    , Ratio = 2
                }
            };
        }

        public List<Flag> List()
        {
            return this._Flags;
        }

        public Flag GetFlag(int id)
        {
            return this._Flags.Where(w => w.Id == id).FirstOrDefault();
        }
    }
}