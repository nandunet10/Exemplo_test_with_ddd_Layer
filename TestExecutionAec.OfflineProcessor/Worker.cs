using MediatR;
using TestExecutionAec.Application.Commands;

namespace TestExecutionAec.OfflineProcessor
{
    public class Worker : BackgroundService
    {
        private IMediator Mediator { get; }
        private readonly ILogger<Worker> _logger;
        public Worker(ILogger<Worker> logger, IMediator mediator)
        {
            _logger = logger;
            Mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Processamento de deados iniciando: {time}", DateTime.Now);

            try
            {
                await Mediator.Send(new ProcessarDadosAecCommand(), stoppingToken);

                _logger.LogInformation("Processamento de dados concluído.");
            }
            catch
            {
                _logger.LogError("Erro ao tentar processar os dados.");
            }

        }

    }
}