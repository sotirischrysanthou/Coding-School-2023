using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarServiceCenterLib {
    public class Manager : Person {

        // Properties
        public double SalaryPerMonth { get; set; }
        public List<Engineer> Engineers { get; set; }
        public DateTime? StartDate { get; set; }
        private String _username { get; set; }
        private String _password { get; set; }

        

        // Constructors
        public Manager() {
            StartDate = null;
        }
        public Manager(string name, string surname, double salaryPerMonth, DateTime startDate) : base(name, surname) {
            Engineers = new List<Engineer>();
            SalaryPerMonth = salaryPerMonth;
            StartDate = startDate;
        }

        // Methods

        public void AddEngineer( Engineer engineer ) {
            Engineers.Add(engineer);
        }
        // TODO :
        public bool LogIn(String userName, String password ) {
            bool ret = false;
            if (true) {
                ret = true;
            }
            return ret;
        }
        //TODO: 
        public void CreateProfile(String userName, String password) { 
            _username = userName;
            _password = password;
        }

        //public bool LogIn(String userName, String password ) {
        //    bool ret = false;
        //    if (StringCipher.Decrypt(password, userName) == password) {
        //        ret = true;
        //    }
        //    return ret;
        //}

        //public void CreateProfile(String userName, String password) { 
        //    _username = userName;
        //    _password = StringCipher.Encrypt(password, userName);
        //}

    }


}
