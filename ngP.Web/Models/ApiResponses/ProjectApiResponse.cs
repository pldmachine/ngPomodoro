using Microsoft.AspNetCore.Mvc.ModelBinding;
using ngP.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngP.Web.Models.ApiResponses
{
    public class ProjectApiResponse
    {
        public bool Status { get; set; }
        public Project Project { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}
