function warningDoIvalidation(){

var DoI = Xrm.Page.getAttribute("amx_documentissuedate").getValue();
var Today = new Date();
 if (DoI > Today)
{
     alert('Date issued cannot be greater than the current day');
     Xrm.Page.getAttribute("amx_documentissuedate").setValue(null); //set null value
 }
}