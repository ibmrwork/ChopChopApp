using ChopChop.Bridg.IBridg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.ViewModel.ViewModel;
using ChopChop.Service.IServices;
using ChopChop.Entity.EntityFramework;
using AutoMapper;
using ChopChop.Service.Services;

namespace ChopChop.Bridg.Bridg
{
    public class VendorBridg : IVendorBridg
    {
        IVendorService _iVendorService = null;
        IVendorTimingService _iVendorTimingService = null;
        IVendorMediaService _iVendorMediaService = null;

        public VendorBridg()
        {
            _iVendorService = new VendorService();
        }
        public VendorBridg(IVendorService iVendorService, IVendorTimingService iVendorTimingService, IVendorMediaService iVendorMediaService)
        {
            this._iVendorService = iVendorService;
            this._iVendorTimingService = iVendorTimingService;
            this._iVendorMediaService = iVendorMediaService;
        }
        public List<ResultSearchRestaurants> SearchRestaurants(SearchResturant searchResturant)
        {
            return _iVendorService.SearchRestaurants(searchResturant);
        }
        public Vendor InsertVendor(VendorViewModel vendorModel)
        {
            //Mapper.Initialize(cfg => { cfg.CreateMap<VendorViewModel, Vendor>(); });

            //var data = Mapper.Map<Vendor>(vendorModel);

            //Vendor vendor = _iVendorService.Insert(data);


            try
            {
                Vendor entity = new Vendor
                {
                    VendorName = vendorModel.VendorName,
                    VendorStyle = vendorModel.VendorStyle,
                    Phone = vendorModel.Phone,
                    AddressLine1 = vendorModel.AddressLine1,
                    LogoPath = vendorModel.LogoPath,
                    C360DegreePath = vendorModel.C360DegreePath,
                    Blurb = vendorModel.Blurb,
                    VendorID = vendorModel.VendorID,
                    IsDeleted=false,
                    CreatedDate=DateTime.Now,
                     MainImagePath = vendorModel.MainImagePath,


                };
                Vendor vendor= _iVendorService.Insert(entity);

                VendorTiming entity2 = new VendorTiming
                {
                    VendorID = vendor.VendorID,
                    VendorTimingID = vendorModel.VendorTimingID,
                    LunchTimeWeakDay = vendorModel.LunchTimeWeakDay,
                    LunchTimeWeakEnd = vendorModel.LunchTimeWeakEnd,
                    LunchWeakDays = vendorModel.LunchWeakDays,
                    LunchWeakEnd = vendorModel.LunchWeakEnd,
                    DinnerTimeWeakDay = vendorModel.DinnerTimeWeakDay,
                    DinnerTimeWeakEnd = vendorModel.DinnerTimeWeakEnd,
                    DinnerWeakDays = vendorModel.DinnerWeakDays,
                    DinnerWeakEnd = vendorModel.DinnerWeakEnd,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                };

               
                _iVendorTimingService.Insert(entity2);

                VendorMedia mediaEntity = new VendorMedia
                {
                    VendorID = vendor.VendorID,
                    OtherImagePath=vendorModel.OtherImagePath,
                    MediaPath=vendorModel.MediaPath,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now
                };
                _iVendorMediaService.InsertVendorMedia(mediaEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

    }
}

