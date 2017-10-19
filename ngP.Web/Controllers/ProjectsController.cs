

using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Domain;
using Microsoft.AspNetCore.Mvc;
using ngP.Web.Models.ApiResponses;
using ngP.Data.Domain;
using System;
using System.Threading.Tasks;
using ngP.Web.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ngP_Web.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {

        public EFContext _context { get; }

        public ProjectsController(EFContext context)
        {
            _context = context;
        }

        // POST api/projects
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(ProjectApiResponse), 201)]
        [ProducesResponseType(typeof(ProjectApiResponse), 400)]
        public async Task<ActionResult> CreateProject([FromBody]Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ProjectApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                await _context.Projects.AddAsync(project);
                await _context.SaveChangesAsync();
                if (project == null)
                {
                    return BadRequest(new ProjectApiResponse { Status = false });
                }
                return CreatedAtRoute("GetProjectrRoute", new { id = project.Id },
                        new ProjectApiResponse { Status = true, Project = project });
            }
            catch (Exception exp)
            {
                return BadRequest(new ProjectApiResponse { Status = false });
            }
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetProjectrRoute")]
        [NoCache]
        [ProducesResponseType(typeof(Project), 200)]
        [ProducesResponseType(typeof(ProjectApiResponse), 400)]
        public async Task<ActionResult> project(int id)
        {
            try
            {
                var customer = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
                return Ok(customer);
            }
            catch (Exception exp)
            {
                return BadRequest(new ProjectApiResponse { Status = false });
            }
        }
    }
}