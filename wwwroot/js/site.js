
try {
    const footer = document.querySelector('footer')

    if (document.body.scrollHeight >= window.innerHeight) {
        footer.classList.remove('position-fixed-bottom')
        footer.classList.add('position-static')
    } else {
        footer.classList.remove('position-static')
        footer.classList.add('position-fixed-bottom')
    }
}
catch { }


function toggleMenu(attribute) {
    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }
}
toggleMenu('[data-option="toggle"]')
function handleClick() {
    var itemLiElements = document.getElementsByClassName("item-li");

    var additionalInfo = document.querySelector('.additional-info');
    var descItem = document.querySelector('.desc-item');

    for (var i = 0; i < itemLiElements.length; i++) {
        var li = itemLiElements[i];

        li.addEventListener("click", function () {
            // Kontrollera om det klickade elementet har ett barn med klassen "item-desc"
            var hasDescription = this.querySelector(".item-desc") !== null;
            // Ta bort btn-theme från alla element
            for (var j = 0; j < itemLiElements.length; j++) {
                itemLiElements[j].classList.remove("btn-theme");

                // Återställ färgen på child elementen
                var childElements = itemLiElements[j].getElementsByTagName("a");
                for (var k = 0; k < childElements.length; k++) {
                    childElements[k].style.color = "";
                }

                //if (itemLiElements[0]) {
                //    additionalInfo.style.display = 'none';
                //    descItem.style.display = 'block';

                //}
                //else if (itemLiElements[1]) {
                //    additionalInfo.style.display = 'block';
                //    descItem.style.display = 'none';

                //}
            }

            // Lägg till btn-theme på det klickade elementet
            this.classList.add("btn-theme");

            // Sätt vit färg på child elementen
            var clickedChildElements = this.getElementsByTagName("a");
            for (var l = 0; l < clickedChildElements.length; l++) {
                clickedChildElements[l].style.color = "white";
            }
            if (hasDescription) {
                // Här kan du utföra ytterligare åtgärder specifika för när "item-desc" finns
                console.log("Det klickade elementet har ett barn med klassen 'item-desc'");
            }
        });
    }

    //if (itemLiElements[0]) {
    //    additionalInfo.style.display = 'none';
    //    descItem.style.display = 'block';

    //}
    
}
handleClick()

//// Hitta elementet med klassen "item-ad-info"
//var itemAdInfo = document.querySelector('.item-ad-info');
//// Hitta elementen med klasserna "additional-info" och "desc-item"
//var additionalInfo = document.querySelector('.additional-info');
//var descItem = document.querySelector('.desc-item');
//var itemDesc = document.querySelector('.item-desc');

//// Lägg till en klickhändelse för elementet
//itemAdInfo.addEventListener('click', function () {
    
//    // Ändra display-egenskapen för elementen
//    additionalInfo.style.display = 'block';
//    descItem.style.display = 'none';
//});

//// Lägg till en klickhändelse för elementet
//itemDesc.addEventListener('click', function () {

//    // Ändra display-egenskapen för elementen
//    additionalInfo.style.display = 'none';
//    descItem.style.display = 'block';
//});



//function checkBtnThemeClass() {
//    var itemLiElements = document.getElementsByClassName("item-li");
//    console.log(itemLiElements,length)

//    for (var i = 0; i < itemLiElements.length; i++) {
//        var li = itemLiElements[i];

//        if (li.classList.contains("btn-theme")) {
//            console.log("btn-theme class found");
//            // Gör något när btn-theme-klassen hittas
//        }
//    }
//}

/*checkBtnThemeClass();*/


//function footerPosition(element, scrollHeight, innerHeight) {
//    try {
//        const _element = document.querySelector(element)
//        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight)

//        if (isTallerThanScreen) {
//            _element.classList.add('position-static')
//            _element.style.marginBottom = '100px' // Lägg till 100px margin bottom
//        } else {
//            _element.classList.remove('position-static')
//            _element.style.marginBottom = '0' // Återställ margin bottom om den är kortare än skärmen
//        }

//        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen)
//    } catch { }
//}

//footerPosition('footer', document.body.scrollHeight, window.innerHeight)


//function footerPosition(element, scrollHeight, innerHeight) {
//    try {
//        const _element = document.querySelector(element)
//        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight )

//        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen)
//        _element.classList.toggle('position-static', isTallerThanScreen)
//    } catch { }
//}
//footerPosition('footer', document.body.scrollHeight, window.innerHeight)


