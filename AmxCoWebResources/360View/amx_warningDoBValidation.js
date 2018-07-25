function warningDoBvalidation(){

var DoB = Xrm.Page.getAttribute("birthdate").getValue();
var Today = new Date();
 if (DoB > Today)
{
     alert('DOB cannot be greater than the current day');
     Xrm.Page.getAttribute("birthdate").setValue(null); //set null value
 }
}