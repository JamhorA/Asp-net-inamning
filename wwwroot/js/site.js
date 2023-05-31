
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
    
}
handleClick()


const validateText = (event) => {
    const input = event.target.value;
    console.log(input);
    if (input.length >= 2) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
        // Om input är tom
        console.log('Text is required.');
        // Gör vidare åtgärder för att hantera felaktig textvalidering
    } else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "invalid length";
        // Om input är giltig
        console.log(event.target.id);
        console.log('Text is valid.');
        // Gör vidare åtgärder för att hantera giltig textvalidering
    }
};


const validateEmail = (event) => {
    const email = event.target.value;
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    if (!emailRegex.test(email)) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Invalid email address.";
        // Om e-postadressen inte matchar mönstret för giltig e-postadress
        console.log('Invalid email address.');
        // Gör vidare åtgärder för att hantera felaktig e-postvalidering
    } else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
        // Om e-postadressen matchar mönstret för giltig e-postadress
        console.log('Valid email address.');
        // Gör vidare åtgärder för att hantera giltig e-postvalidering
    }
};

const validatePassword = (event) => {
    const password = event.target.value;
    if (password.length < 8) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Password should be at least 8 characters long.";
        // Om lösenordet är för kort
        console.log('Password should be at least 8 characters long.');
        // Gör vidare åtgärder för att hantera felaktig lösenordsvalidering
    } else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
        // Om lösenordet är tillräckligt långt
        console.log('Valid password.');
        // Gör vidare åtgärder för att hantera giltig lösenordsvalidering
    }
};



// Funktion för att rensa felmeddelandet
function clearErrorMessage() {
    var errorMessage = this.nextElementSibling.querySelector(".text-denger");
    errorMessage.textContent = "";
}




