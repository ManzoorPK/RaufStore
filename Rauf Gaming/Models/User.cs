using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rauf_Gaming.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
   
    public class Dashboard
    {
        [Key]
        public int Id { get; set; }
        public int Orders { get; set; }
        public int Ps4New { get; set; }
        public int XBoxNew { get; set; }
        public int NintendoNew { get; set; }
        public int Ps4Used { get; set; }
        public int XBoxUsed { get; set; }
        public int NintendoUsed { get; set; }
        public int Ps4NewGames { get; set; }
        public int XBoxNewGames { get; set; }
        public int NintendoNewGames { get; set; }
        public int Ps4UsedGames { get; set; }
        public int XBoxUsedGames { get; set; }
        public int NintendoUsedGames { get; set; }
        public int TV { get; set; }
        public int VR { get; set; }
        public int JoyStick { get; set; }
        public int HeadSet { get; set; }
        public int Keyboard { get; set; }
        public int Camera { get; set; }
        public int Mouse { get; set; }
        public int Speaker { get; set; }
       


    }
}