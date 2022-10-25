using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.Domain.Modules.AdvertisementModule.Aggregate;
using ITJob.EntityFramework.Write.Context.Interfaces;
using ITJob.Message.Command.AdvertisementModule.Messages;
using MassTransit;
using SAF.SSN.Kernel.CommandBus.Handling;

namespace ITJob.CommandHandler.Modules.AdvertisementModule
{
    public class AdvertisementCommandHandler :
        ICommandHandler<CreateAdvertisementCommand>,
        ICommandHandler<UpdateAdvertisementCommand>,
        ICommandHandler<DeleteAdvertisementCommand>,
        ICommandHandler<ConfirmAdvertisementCommand>
    {
        private readonly IRepository<Advertisement> _advertisementRepository;
        private readonly IContext _context;
        //private readonly IBus _bus;

        public AdvertisementCommandHandler(IContext context, IRepository<Advertisement> advertisementRepository)
        {
            _context = context;
            _advertisementRepository = advertisementRepository;
            //_bus = bus;
        }

        public void Handle(CreateAdvertisementCommand command)
        {
            var ad = new Advertisement();
            // ToDO Some Thing
            _advertisementRepository.Add(ad);
            _context.SaveChanges();
        }

        public void Handle(UpdateAdvertisementCommand command)
        {
            var ad = _advertisementRepository.Find(command.CommandId);
            // ToDO Some Thing
            _advertisementRepository.Update(ad);
            _context.SaveChanges();
        }

        public void Handle(DeleteAdvertisementCommand command)
        {
            var ad = _advertisementRepository.Find(command.CommandId);
            // ToDO Some Thing
            _advertisementRepository.Remove(ad);
            _context.SaveChanges();
        }

        public void Handle(ConfirmAdvertisementCommand command)
        {
            var ad = _advertisementRepository.Find(command.CommandId);
            // ToDO Some Thing
            _advertisementRepository.Update(ad);
            _context.SaveChanges();
        }
    }
}
