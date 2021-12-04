﻿/*
 * lufer
 * ISI
 * */
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;   //[Authorize]
using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    /// <summary>
    /// Gestor de Autenticações - Authentication Manager
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        //Esta componente de dados poderia passar para Models!
        //Simular Base de Dados
        static List<User> users = new List<User>
        {
            new User() {Id = 1, Name = "lufer", Pass = "Benfica2020", Role = Roles.Admin },
            new User() {Id = 4, Name = "user", Pass = "user", Role = Roles.User },
            new User() {Id = 2, Name="reader", Pass="reader", Role = Roles.Reader }
        };


        public UserController()
        {
            if (users == null) users = new List<User>();
        }

        // GET api/all            
        [HttpGet("all")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            ////Simular dois users
            //User x0 = new User() { Id = 1, Name = "lufer", Pass = "Benfica2020", Role = Roles.Admin };
            //User x1 = new User() {Id=2, Name = "user", Pass = "user", Role = Roles.User };
            //User x2 = new User() {Id=3, Name="reader", Pass="reader", Role = Roles.Reader };
            //if (!users.Contains(x1)) users.Add(x1);
            //if (!users.Contains(x0)) users.Add(x0);
            //if (!users.Contains(x2)) users.Add(x2);

            return new ObjectResult(users);
        }

        // GET api/get/5
        //[Authorize(Roles = "admin")]
        [HttpGet("get/{id}")]
        public ActionResult<User> Get(int id)
        {
            return users.Single(x => x.Id == id);
        }

        // POST api/values
        //[Authorize]
        [HttpPost("addUser")]
        public ActionResult<bool> Post(User u)
        {
            if (users.Contains(u)) return false;
            users.Add(u);
            return true;

        }


        // PUT api/values/5
        //[Authorize]
        [HttpPatch("updatePass/{name}")]    //PATCH...update properties
        public ActionResult<bool> ChangePass(string name,[FromBody] string passwd)
        {
            int i = users.FindIndex(x => x.Name == name);
            if (i >= 0)
            {
                users[i].Pass = passwd;
                return true;
            }
            return false;
        }

        //[Authorize]
        [HttpPut("updateUser")]
        public ActionResult<bool> Put(User u)
        {
            int i = users.FindIndex(x => x.Id == u.Id);
            if (i >= 0)
            {
                users[i].Pass = u.Pass;
                users[i].Name = u.Name;
                return true;
            }
            return false;
        }

        // DELETE api/values/5
        //[Authorize(Roles = "admin")]
        //[Authorize]
        [HttpDelete("deleteUser/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            User aux = users.Single<User>(x => x.Id == id);
            if (aux!=null)
                {
                users.Remove(aux);
                return true;
            }
            return false;
        }

    }
}
