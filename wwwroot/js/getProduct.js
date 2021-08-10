var type = document.querySelector("#typeId");
var searchName = document.querySelector("#nameId");
var searchCategory = document.querySelector("#categoryId");
var buttonConf =  document.querySelector("#buttonConfId");
var buttonSubmit =  document.querySelector("#buttonId");




buttonConf.addEventListener("click",function()
{
    if(type.value=="1") 
    {
        searchName.classList.remove("searchForm");
        buttonConf.classList.add("searchForm");
        buttonSubmit.classList.remove("searchForm")
    }
})

   

    



