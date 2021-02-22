(function ($) {
    $.fn.mulDistrictsCtl = function (settings) {
        var _coordSys = "";
        var _isProjectiveGeo = "";
        //默认选项
        var defaluts =
            {
                provinceId: "",//初始化省的个数
                selectProviceId: "",//选中省
                selectCityId: "",//选中市
                selectCounty: "",//选中县
                showTown: false,
                html: "",
                type: 'T',
            };
        defaluts.provinceId = settings.provinceId;
        $.extend(defaluts, settings);
        var _district = $(this).empty();
        var _html;
        if (defaluts.html) {
            _html = defaluts.html;
        }
        else {
            if (defaluts.type == 'B') {
                _html = '<div style="float: left;width:100%;display: flex;align-items: center;flex-wrap: nowrap;">';
                _html += '<span class="spans" style="float:left;">省：</span><div id="PROVINCE" multiples="true" type="select" class="ui-select divselect" style="float: left;width: 20%;"></div>';
                _html += '<span class="spans" style="float:left;">市：</span><div id="CITY" type="select" multiples="true" class="ui-select divselect" style="float: left;width: 20%;"></div>';
                _html += '<span class="spans" style="float:left;">县(区)：</span><div id="COUNTY" type="select" multiples="true" class="ui-select divselect" style="float: left;width: 20%;"></div>';
                if (defaluts.showTown == true)
                    _html += '<span class="spans" style="float:left;">乡镇：</span><div id="TOWN" type="select" multiples="true" class="ui-select divselect" style="float: left;"></div></div>';
                else
                    _html += '<span class="spans" style="float:left;display:none;">乡镇：</span><div id="TOWN" multiples="true" type="select" class="ui-select divselect" style="float: left;display:none;"></div></div>';
            } else if (defaluts.type == 'Z') {
                _html = '<div style="width:100%">';
                _html += '<div style="width: 100%; height: 40px;"><span class="spans" style="display: inline-block; width: 29%; text-align: center">省：</span><div id="PROVINCE" multiples="true" type="select" class="ui-select" style="display: inline-block; width: 66%"></div></div>';
                _html += '<div style="width: 100%; height: 40px;"><span class="spans" style="display: inline-block; width: 29%; text-align: center">市：</span><div id="CITY" type="select" multiples="true" class="ui-select" style="display: inline-block; width: 66%"></div></div>';
                _html += '<div style="width: 100%; height: 40px;"><span class="spans" style="display: inline-block; width: 29%; text-align: center">县(区)：</span><div id="COUNTY" type="select" multiples="true" class="ui-select" style="display: inline-block; width: 66%"></div></div>';
                //if (defaluts.showTown == true)
                //    _html += '<div style="width: 100%; height: 40px;"><span class="spans" style="display: inline-block; width: 29%; text-align: center">乡镇：</span><div id="TOWN" multiples="true" type="select" class="ui-select" style="display: inline-block; width: 66%"></div></div></div>';
                //else
                //    _html += '<div style="width: 100%; height: 40px;"><span class="spans" style="display: inline-block; width: 29%; text-align: center;display:none;">乡镇：</span><div id="TOWN" multiples="true" type="select" class="ui-select" style="display: inline-block; width: 66%;display:none;"></div></div></div>'
            } else {
                _html = " <table><tr><td class=\"formTitle\">省</td><td> <div id=\"PROVINCE\" multiples=\"true\" type=\"select\" class=\"ui-select\" style=\"float: left; width: 160px; margin-right: 1px;\"></div></td></tr>" +
                                "<tr><td class=\"formTitle\">市</td><td><div id=\"CITY\" multiples=\"true\" type=\"select\" class=\"ui-select\" style=\"float: left; width: 160px; margin-right: 1px;\"></div></td></tr>" +
                                "<tr><td class=\"formTitle\">区</td><td><div id=\"COUNTY\" multiples=\"true\" type=\"select\" class=\"ui-select\" style=\"float: left; width: 160px; margin-right: 1px;\"></div> </td></tr></table>";
                //  _html = '<div style="float: left; width: 255px;"><div id="PROVINCE" type="select" multiples class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div><div id="CITY" type="select" multiples class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div><div id="COUNTY" type="select" multiples class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div></div>';
            }
        }
        _district.append(_html);
        var _provinceCommbox = _district.find("#PROVINCE");
        var _cityCommbox = _district.find("#CITY");
        var _countyCommbox = _district.find("#COUNTY");
        //var _addressText = _district.find("#F_Address");
        //省份
        _provinceCommbox.ComboBoxEx({
            url: contentPath + "/SystemManage/Area/GetProvinceListJson",
            param: { codes: "0", provinceIds: defaluts.provinceId },
            id: "F_AreaCode",
            text: "F_AreaName",
            description: "选择省",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            _cityCommbox[0].innerHTML = "选择市";
            _cityCommbox.attr('data-value', '');
            _countyCommbox[0].innerHTML = "选择县/区";
            _countyCommbox.attr('data-value', '');
            if (!value) {
                value = "abcdef";
            }
            _cityCommbox.ComboBoxEx({
                url: contentPath + "/SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择市",
                height: "170px"
            });
            _countyCommbox.ComboBoxEx({
                url: contentPath + "/SystemManage/Area/GetAllByParentCodes",
                param: { codes: "" },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择县/区",
                height: "170px"
            });
        });
        if (defaluts.selectProviceId != "") {
            _cityCommbox.ComboBoxEx({
                url: contentPath + "/SystemManage/Area/GetAllByParentCodes",
                param: { codes: defaluts.selectProviceId },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择市",
                height: "170px"
            });
        }
        if (defaluts.selectCityId != "") {
            _countyCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: defaluts.selectCityId },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择县/区",
                height: "170px"
            });
        }
        //城市
        _cityCommbox.ComboBoxEx({
            description: "选择市",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            _countyCommbox[0].innerHTML = "选择县/区";
            _countyCommbox.attr('data-value', '');
            if (!value) {
                $("#CITY").find(".ui-select-text").text("选择市");
                $("#CITY").find(".ui-select-text").css("color", "#999");
                value = "abcdef";
            }
            //if (value) {
            _countyCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择县/区",
                height: "170px"
            });
            //}
        });
        //县/区
        _countyCommbox.ComboBoxEx({
            description: "选择县/区",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            if (!value) {
                $("#COUNTY").find(".ui-select-text").text("选择县/区");
                $("#COUNTY").find(".ui-select-text").css("color", "#999");
            }
        });
        if (defaluts.selectProviceId == "0") {
            defaluts.selectProviceId = "";
        }
        _provinceCommbox.comboBoxSetValue(defaluts.selectProviceId);
        _cityCommbox.comboBoxSetValue(defaluts.selectCityId);
        _countyCommbox.comboBoxSetValue(defaluts.selectCounty);
        //_addressText.val(defaluts.address);
        function setDistrictValue(provinceid, cityid, countyid, address) {
            var _province = _district.find("#PROVINCE");
            var _city = _district.find("#CITY");
            var _county = _district.find("#COUNTY");
            //var _address = _district.find("#F_Address");
            _province.comboBoxSetValue(provinceid);
            _city.comboBoxSetValue(cityid);
            _county.comboBoxSetValue(countyid);
            //_address.val(address);
        }
        function getDistrictValue() {
            var districtInfo = {
                provinceId: "",
                provinceName: "",
                cityId: "",
                cityName: "",
                countyId: "",
                countyName: "",
                address: "",
                xzqhcode: ""
            };
            var _province = _district.find("#PROVINCE");
            var _city = _district.find("#CITY");
            var _county = _district.find("#COUNTY");
            districtInfo.provinceId = _province[0].dataset.value;
            districtInfo.provinceName = _province[0].dataset.text;
            districtInfo.cityId = _city[0].dataset.value;
            districtInfo.cityName = _city[0].textContent;
            districtInfo.countyId = _county[0].dataset.value;
            districtInfo.countyName = _county[0].textContent;
            //districtInfo.address = _district.find("#F_Address").val();
            if (districtInfo.provinceId) {
                districtInfo.xzqhcode = districtInfo.provinceId;
            }
            if (districtInfo.cityId) {
                districtInfo.xzqhcode = districtInfo.cityId;
            }
            if (districtInfo.countyId) {
                districtInfo.xzqhcode = districtInfo.countyId;
            }
            return districtInfo;
        }
        _district[0].d = {
            setDistrictValue: function (provinceid, cityid, countyid, address) {
                setDistrictValue(provinceid, cityid, countyid, address)
            },
            getDistrictValue: function () {
                return getDistrictValue();
            }
        };
        return _district;
    };
    $.fn.setDistrictValue = function (provinceid, cityid, countyid, address) {
        if (this[0].d) {
            this[0].d.setDistrictValue(provinceid, cityid, countyid, address);
        }
        return null;
    };
    $.fn.getDistrictValue = function () {
        if (this[0].d) {
            return this[0].d.getDistrictValue();
        }
        return null;
    };
})(jQuery);