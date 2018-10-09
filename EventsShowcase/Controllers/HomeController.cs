﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using EventsShowcase.Util;
using EventsShowcase.Models;

namespace EventsShowcase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Debug.WriteLine("################### Calling Index:getEventList");
            return View(DataStore.getEventsList());
        }

        [HttpGet]
        public ActionResult CreateEvent()
        {
            Debug.WriteLine("################### Calling CreateEvent");
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(EventModel newEvent)
        {
            //add newEvent to the list  and redirect to home index page and show the new event in the list
            Debug.WriteLine("################### Adding new Event to List, newEvent=" + newEvent);
            newEvent.ID = DataStore.getEventsList().Count;
            addNewEventToList(newEvent);
            Debug.WriteLine("################### EventList Count=" + DataStore.getEventsList().Count);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            int editEventID = id;
            Debug.WriteLine("################### Calling EditEvent for editEventID" + editEventID);
            EventModel editEventItem = DataStore.getEventsList().ElementAt(editEventID);
            Debug.WriteLine("################### EditEvent details before editing:" + editEventItem.Title);
            return View(editEventItem);
        }

        [HttpPost]
        public ActionResult EditEvent(EventModel toEditEventItem)
        {
            Debug.WriteLine("################### Calling EditEvent toEditEventItem");
            //delete thye old item first
            DataStore.getEventsList().RemoveAt(toEditEventItem.ID);
            //insert the edited item at the same index
            DataStore.getEventsList().Insert(toEditEventItem.ID, toEditEventItem);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
            int toDeleteEventID = id;
            Debug.WriteLine("################### Calling DeleteEvent for toDeleteEventID");
            EventModel deleteEventItem = DataStore.getEventsList().ElementAt(toDeleteEventID);
            Debug.WriteLine("################### DeleteEvent details before editing:" + deleteEventItem.Title);
            return View(deleteEventItem);
        }

        [HttpPost]
        public ActionResult DeleteEvent(EventModel toDeleteEventItem)
        {
            Debug.WriteLine("################### Calling DeleteEvent toDeleteEventItem");
            //delete the event item from the list
            DataStore.getEventsList().RemoveAt(toDeleteEventItem.ID);
            return RedirectToAction("Index");
        }

        public ActionResult ViewEvent(int id)
        {
            int eventID = id;
            Debug.WriteLine("################### Calling ViewEvent for eventID" + eventID);
            EventModel eventItem = DataStore.getEventsList().ElementAt(eventID);
            return View(eventItem);
        }


        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    
        private void addNewEventToList(EventModel newEvent)
        {
            Debug.WriteLine("################### Calling addNewEventToList");
            DataStore.getEventsList().Add(newEvent);

        }
    }
}