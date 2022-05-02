using System;
using System.Collections.Generic;

#nullable disable

namespace CovoitAdmin2.Model
{
    public partial class User
    {
        public int IdUser { get; set; }
        public int Tel { get; set; }
        public bool? Contacts { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string ImgProfil { get; set; }
        public bool? Administrator { get; set; }
        public string Password { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModification { get; set; }
    }
}
