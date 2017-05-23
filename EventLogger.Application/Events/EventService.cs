using EventLogger.Application.Events.Dto;
using EventLogger.Core.Domain;
using EventLogger.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogger.Application.Events
{
   public class EventService : IEventService
    {

        #region properties

        private readonly IDbSet<Event> _Events;
        private readonly IUnitOfWork _uow;

        #endregion

        #region Ctor

        public EventService(IUnitOfWork uow)
        {
            _uow = uow;
            _Events = _uow.Set<Event>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Create(EventInput input)
        {
            var Event = new Event
            {
                Action = input.Action,
                Controller = input.Controller,
                RouteValues = input.RouteValues,
                UserName = input.UserName,
                CreateDateTime = DateTime.Now,
                
            };

            _Events.Add(Event);
            _uow.SaveChanges();
        }






        /// <summary>
        /// 
        /// </summary>
        public EventInput Get(int id)
        {
            var Event = _Events.FirstOrDefault(e => e.Id == id);

            if (Event == null)
            {
                throw new Exception("Event not found in database");
            }

            return new EventInput
            {
                Id = Event.Id,
                Action = Event.Action,
                Controller = Event.Controller,
                RouteValues = Event.RouteValues,
                UserName = Event.UserName,
                CreateDateTime = Event.CreateDateTime,
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<EventInput> Search()
        {
            return _Events.Select(Event => new EventInput
            {
                Id = Event.Id,
                Action = Event.Action,
                Controller = Event.Controller,
                RouteValues = Event.RouteValues,
                UserName = Event.UserName,
                CreateDateTime = Event.CreateDateTime,


            }).ToList();
        }






        /// <summary>
        /// 
        /// </summary>
        public int Count()
        {
            return _Events.Count();
        }






        #endregion

        #region Private Methods


        #endregion

    }
}
