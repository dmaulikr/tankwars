using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankWars.Service.Exceptions {
    class InvalidNumberException : Exception {

        public InvalidNumberException() : base() {

        }
        public InvalidNumberException(string msg) : base(msg) {

        }
    }
}
