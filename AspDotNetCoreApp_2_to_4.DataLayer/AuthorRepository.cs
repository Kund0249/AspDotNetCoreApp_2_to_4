using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AspDotNetCoreApp_2_to_4.DataLayer
{
    public class AuthorRepository
    {
        public List<AuthorEntity> GetAuthors
        {
            get
            {
                //int[] ar = new int[5];
                //ArrayList ar = new ArrayList();
                //ar.Add(1);
                //ar.Add("gh");


                //Code to connect with DB and get all the records as per business logic.
                //List<AuthorEntity> authorEntities = new List<AuthorEntity>();

                //authorEntities.Add(new AuthorEntity()
                //{
                //    AuthorId = 1,
                //    AuthorName = "John Smith",
                //    EmailAddress = "john@gmail.com",
                //    Mobile = "786534213"
                //});
                //authorEntities.Add(new AuthorEntity()
                //{
                //    AuthorId = 3,
                //    AuthorName = "Sam Smith",
                //    EmailAddress = "Sam@gmail.com",
                //    Mobile = "786534213"
                //});
                //authorEntities.Add(new AuthorEntity()
                //{
                //    AuthorId = 3,
                //    AuthorName = "Briti",
                //    EmailAddress = "briti@gmail.com",
                //    Mobile = "786534213"
                //});

                //return authorEntities;

                return new List<AuthorEntity>()
                {
                    new AuthorEntity()
                        {
                            AuthorId = 1,
                            AuthorName = "John Smith",
                            EmailAddress = "john@gmail.com",
                            Mobile = "786534213"
                        },
                    new AuthorEntity()
                        {
                            AuthorId = 1,
                            AuthorName = "Sam Smith",
                            EmailAddress = "sam@gmail.com",
                            Mobile = "786534213"
                        },
                    new AuthorEntity()
                        {
                            AuthorId = 1,
                            AuthorName = "Briti",
                            EmailAddress = "briti@gmail.com",
                            Mobile = "786534213"
                        }
                };
            }
        }
    }
}
