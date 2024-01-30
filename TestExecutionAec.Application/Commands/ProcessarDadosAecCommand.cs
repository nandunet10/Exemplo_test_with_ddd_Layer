using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestExecutionAec.Application.Commands;
public class ProcessarDadosAecCommand : IRequest<IActionResult> { }
