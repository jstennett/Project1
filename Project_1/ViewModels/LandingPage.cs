using Project_1.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.ViewModels
{
    public class LandingPage
    {
        public List<IRestResponse<CharacterResult>> heroes = new List<IRestResponse<CharacterResult>>();
    }
}