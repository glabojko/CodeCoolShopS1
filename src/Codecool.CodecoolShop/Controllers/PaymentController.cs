﻿using System;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.IO;
using Newtonsoft.Json;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Controllers
{
	public class PaymentController : Controller
	{
       
        public IActionResult Index()
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.DefaultPrice * item.Quantity);
            }

            return View();
        }
        //[HttpPost]
        public IActionResult OrderConfirmation(int id, string firstname, string lastname, string email, string phonenumber,
            string countrybill, string citybill, string zipcodebill, string streetbill, string numberbill,
            string countryship, string cityship, string zipcodeship, string streetship, string numbership)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            OrderModel orderDetails = new OrderModel(id, firstname, lastname, email, phonenumber,
             countrybill, citybill, zipcodebill, streetbill, numberbill,
            countryship, cityship, zipcodeship, streetship, numbership);

            var orderDetailsDictionary = orderDetails.GetOrderDetails();
            //string Cart = JsonConvert.SerializeObject(cart.ToArray());

            //string OrderDetails = JsonConvert.SerializeObject(orderDetailsDictionary.ToArray());

            //write string to file
            //System.IO.File.WriteAllText(@"/Users/sofia/Documents/C#/CodeCoolShopS1/src/Codecool.CodecoolShop/JSONFiles/Order.json", Cart);
            //System.IO.File.WriteAllText(@"/Users/sofia/Documents/C#/CodeCoolShopS1/src/Codecool.CodecoolShop/JSONFiles/Order.json", OrderDetails);
            string json1 = JsonConvert.SerializeObject(orderDetailsDictionary, Formatting.Indented);
            //string json2 = JsonConvert.SerializeObject(orderDetailsDictionary.ToString());
            //System.IO.File.WriteAllText(@"E:\programowanie\projekty\C#\koszyk\irytujacyKoszyk.json", json1);
            //System.IO.File.WriteAllText(@"E:\programowanie\projekty\C#\koszyk\irytujacyKoszyk.json", json2);

            return View();
        }
       
    }
}

