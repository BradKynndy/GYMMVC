using System;
using GYMMVC.Models;
using GYMMVC.Models.Enuns;

namespace GYMMVC.Models;

    public class MembersViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordString { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int Nivelconta { get; set; }
        public ClasseEnum Classe { get; set; }
    }
