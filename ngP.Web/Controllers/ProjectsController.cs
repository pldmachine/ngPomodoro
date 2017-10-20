

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
using ngP.Data.Infrastructure;

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

        [HttpGet("page/{skip}/{take}")]
        [NoCache]
        [ProducesResponseType(typeof(List<Project>), 200)]
        [ProducesResponseType(typeof(ProjectApiResponse), 400)]
        public async Task<ActionResult> ProjectsPage(int skip, int take)
        {
            try
            {
                var totalRecords = await _context.Projects.CountAsync();
                var pagingResult = await _context.Projects.Skip(skip).Take(take).ToListAsync();
                var result = new PagingResult<Project>(pagingResult, totalRecords);
                Response.Headers.Add("X-InlineCount", result.TotalRecords.ToString());
                return Ok(result.Records);
            }
            catch(Exception ex)
            {
                return BadRequest(new ProjectApiResponse { Status = false });
            }
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
                return CreatedAtRoute("GetProjectRoute", new { id = project.Id },
                        new ProjectApiResponse { Status = true, Project = project });
            }
            catch (Exception exp)
            {
                return BadRequest(new ProjectApiResponse { Status = false });
            }
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetProjectRoute")]
        [NoCache]
        [ProducesResponseType(typeof(Project), 200)]
        [ProducesResponseType(typeof(ProjectApiResponse), 400)]
        public async Task<ActionResult> Project(int id)
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

        // PUT api/customers/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(ProjectApiResponse), 200)]
        [ProducesResponseType(typeof(ProjectApiResponse), 400)]
        public async Task<ActionResult> UpdateProject(int id, [FromBody]Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ProjectApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                _context.Projects.Attach(project);
                _context.Entry(project).State = EntityState.Modified;

                var status = (await _context.SaveChangesAsync() > 0 ? true : false);
                if (!status)
                {
                    return BadRequest(new ProjectApiResponse { Status = false });
                }
                return Ok(new ProjectApiResponse { Status = true, Project = project });
            }
            catch (Exception exp)
            {
                return BadRequest(new ProjectApiResponse { Status = false });
            }
        }
    }
}