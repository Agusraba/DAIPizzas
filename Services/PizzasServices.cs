using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Dapper;
using System.Data.SqlClient;
using Pizzas.API.Utils;

namespace Pizzas.API.Services {
    public class PizzaServices {
        public static List<Pizza> GetAll() {
            string sp;
            List<Pizza> returnList;

            returnList = new List<Pizza>();
            using (SqlConnection db = BD.GetConnection()) {
                sp = "sp_TodoDePizzas";
                returnList = db.Query<Pizza>(sp, commandType: CommandType.Stored.Procedures).ToList();
            }

            return returnList;
        } 

        
        public static Pizza ConsultaPizzas (int IdPizza)
        {
            string sp;
            Pizza PizzaBuscada;

            using (SqlConnection db = BD.GetConnection()) {
                sp = "sp_GetById";
                PizzaBuscada = db.QueryFirstOrDefault<Pizza>(sp, new {pId = IdPizza}, commandType: CommandType.Stored.Procedures);
            }

            return PizzaBuscada;
        }

            public static void AgregarPizza (Pizza Pizza){
                string sp;

                using (SqlConnection db = BD.GetConnection()) {
                    sp = "sp_update";
                
                    db.Execute(sp, new{ pNombre = Pizza.Nombre, pLibreGluten = Pizza.LibreGluten, pImporte = Pizza.Importe, pDescripcion = Pizza.Descripcion}, commandType: CommandType.Stored.Procedures );
                }
            }

            public static void ModificarPizza (int id,Pizza Pizza){
                string sp;

                using (SqlConnection db = BD.GetConnection()) {
                    sp = "sp_insert  ";
                   
                    db.QueryFirstOrDefault(sp, new{ pId = id, pNombre = Pizza.Nombre, pLibreGluten = Pizza.LibreGluten, pImporte = Pizza.Importe, pDescripcion = Pizza.Descripcion}, commandType: CommandType.Stored.Procedures);
                }
            }
            public static void EliminarPizza (int id){
                string sp;

                using (SqlConnection db = BD.GetConnection()) {
                    sp = "sp_delete";
               
                    db.Execute(sp, new{ pId = id}, commandType: CommandType.Stored.Procedures );
                    

                }
            }
             
        }
}