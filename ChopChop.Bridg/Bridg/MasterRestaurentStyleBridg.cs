using ChopChop.Bridg.IBridg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity.EntityFramework;
using ChopChop.Service.IServices;
using ChopChop.ViewModel.ViewModel;
using ChopChop.Service.Services;
using AutoMapper;

namespace ChopChop.Bridg.Bridg
{
    public class MasterRestaurentStyleBridg : IMasterRestaurentStyleBridg
    {
        readonly IMasterRestaurentStyleService  _masterRestaurentStyleService;
        public MasterRestaurentStyleBridg()
        {
            _masterRestaurentStyleService = new MasterRestaurentStyleService();
        }

        public MasterRestaurentStyleBridg(IMasterRestaurentStyleService masterRestaurentStyleService)
        {
            this._masterRestaurentStyleService = masterRestaurentStyleService;
        }
       
        public IEnumerable<MasterRestaurentStyleViewModel> GetAll()
        {
            var styles = _masterRestaurentStyleService.GetAll();
            Mapper.Initialize(map => { map.CreateMap<MasterRestaurentStyle, MasterRestaurentStyleViewModel>(); });
            var restaurentStyles = Mapper.Map<IEnumerable<MasterRestaurentStyle>, IEnumerable<MasterRestaurentStyleViewModel>>(styles);
            return restaurentStyles;
           
        }
    }
}
