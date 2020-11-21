using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Answer
    {
        #region Declaracion de variables

        private bool _status;
        private string _message;
        private dynamic _data;

        #endregion

        #region Metodos Getter And Setter
        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }

        public dynamic data
        {
            get { return _data; }
            set { _data = value; }
        }

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        #endregion

        #region Constructor
        public Answer()
        {
            this._status = false;
            this._data = new List<System.Dynamic.ExpandoObject>();
            this._message = null;
        }

        #endregion
    }
}