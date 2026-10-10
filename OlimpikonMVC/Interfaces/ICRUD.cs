using System;
using System.Collections.Generic;
using System.Text;
using OlimpikonMVC.Models;
namespace OlimpikonMVC.Interfaces
{
    public interface ICRUD
    {
        List<Orszag> Read();

        string Insert(Orszag orszag);

        string Update(Orszag orszag);

        string Delete(int id);
    }
}
