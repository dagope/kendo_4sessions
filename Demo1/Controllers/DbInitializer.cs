//using Demo1.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Demo1.Controllers
//{
//    public class DbInitializer
//    {
//        public void Init(Demo1Context db)
//        {
//            Random rand = new Random();

//            var listaPivote = new List<Persona>()
//            {
//                new Persona(){ Profesion="Developer"      ,Apellido="Hanselman",Nombre="Scott"   , Nacionalidad="EEUU"},
//                new Persona(){ Profesion="Médico",   Apellido="Stallman",     Nombre="Richard"   , Nacionalidad="Francia"},
//                new Persona(){ Profesion="Vividor", Apellido="Gates",       Nombre="Bill"          , Nacionalidad="España"},
//                new Persona(){ Profesion="Enfermero",Apellido="Jobs",        Nombre="Steve"         , Nacionalidad="Bélgica"},
//                new Persona(){ Profesion="Piloto",Apellido="Torvalds",    Nombre="Linus"         , Nacionalidad="Holamda"},
//                new Persona(){ Profesion="CEO",   Apellido="Ballmer",      Nombre="Steve"           , Nacionalidad="España"},
//                new Persona(){ Profesion="Capitán",  Apellido="Parker",         Nombre="Peter"           , Nacionalidad="Portugal"},
//                new Persona(){ Profesion="Periodista",  Apellido="Kent",      Nombre="Clart"          , Nacionalidad="Japón"},
//                new Persona(){ Profesion="Físico",   Apellido="Willis",         Nombre="Bruce"        , Nacionalidad="Italia"},
//                new Persona(){ Profesion="Deportista",Apellido="Bolt",     Nombre="Usain"    , Nacionalidad="Suiza"}
//            };

//            var i = db.Personas.Count() + 1;
//            var listaFull = from persona in listaPivote
//                            from persona2 in listaPivote
//                            from persona3 in listaPivote
//                            from persona4 in listaPivote
//                            select new Persona()
//                            {
//                                Id = i++,
//                                Nombre = persona.Nombre,
//                                Apellido = persona2.Apellido,
//                                Profesion = persona3.Profesion,
//                                Edad = rand.Next(99),
//                                Nacionalidad = persona4.Nacionalidad
//                            };
//            var ListaPersonas = new List<Persona>(listaFull.Take(25));

//            foreach (var item in db.Personas)
//            {
//                db.Personas.Remove(item);
//            }
//            db.SaveChanges();
//            db.Personas.AddRange(ListaPersonas);
//            db.SaveChanges();

//        }
//    }
//}