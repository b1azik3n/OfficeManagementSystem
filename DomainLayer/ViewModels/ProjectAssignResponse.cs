using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels
{
    public class ProjectAssignResponse
    {
        public string ProjectName { get; set; }

        public List<ProjectUserResponse> UserDesignation { get; set; }

    }
}
