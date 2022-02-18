//***CODE BEHIND - BY RODOLFO.FONSECA***//

using Quartz;

namespace CodeBehind.TiroCurto.ServicoComRelogio
{
    public static class RelogioExtensions
    {
        public static void AddJobAndTrigger<T>(
            this IServiceCollectionQuartzConfigurator quartz,
            IConfiguration config)
            where T : IJob
        {
            //Pegar nome da classe - mesmo nome da chave do config
            string nomeJob = typeof(T).Name;

            var configKey = $"Quartz:{nomeJob}";
            var cronHorarioExecucao = config[configKey]; //5seg

            if (string.IsNullOrEmpty(cronHorarioExecucao))
            {
                throw new Exception($"No Quartz.NET Cron schedule found for job in configuration at {configKey}");
            }

            //registrando o job
            var jobKey = new JobKey(nomeJob);
            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(nomeJob + "-trigger")
                .WithCronSchedule(cronHorarioExecucao));
        }
    }
}
