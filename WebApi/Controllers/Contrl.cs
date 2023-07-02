using Microsoft.AspNetCore.Mvc;
using Persistence.Repository;

namespace WebApi.Controllers;

[ApiController]
public class Contrl : ControllerBase
{
    public Contrl(Repo repo)
    {
    }
}