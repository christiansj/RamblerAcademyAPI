using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Controllers
{
    public interface IApiController<T>
    {
        Task<ActionResult> Get();
        Task<ActionResult> Get(int id);
        Task<ActionResult> Post(T t);
        Task<ActionResult> Put(int id, T t);
        Task<ActionResult> Delete(int id);
    }
}
