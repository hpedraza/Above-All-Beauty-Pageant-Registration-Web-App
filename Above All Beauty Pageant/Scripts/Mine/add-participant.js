$(document).ready(function () {
    let dropDown = $("#add-participant-form > div:nth-child(6) > select");
    let maleCategories = [];
    let femaleCategories = [];

    const enableFormControls = (...divs) => {
        $(divs.join()).css('display', 'block');
    }

    const addToOneofTheCategories = (maleCategories, femaleCategories, group, isParticipantFemale) => {
        isParticipantFemale ? femaleCategories.push(group) : maleCategories.push(group);
    }

    const generateGenderDropDown = (genderGroups) => {
        console.log(genderGroups);
        let html = '';
        for (let group of genderGroups) {
            html += `<option value="${group.value}">${group.group}</option>`
        }
        dropDown.html(html);
    }

    const isFemale = (group) => {
        const words = group.split(" ");
        const lastWord = words[words.length - 1];
        console.log(`lastWord: ${lastWord}`);
         return lastWord == 'Miss' ? true : false;
    }

    const disableFormControls = (...divs) => {
        $(divs.join()).css('display', 'none');
    }

    const invertButtonDiability = (button , disable) => {
        disable ? button.disabled = true : button.disabled = false;
    }

    const done = (categories) => {

        for (let group of JSON.parse(categories)) {
            addToOneofTheCategories(maleCategories, femaleCategories, group, isFemale(group.group));
        }
        generateGenderDropDown(maleCategories);
    dropDown.html(html);



        
}


    $('#event-drop-down-list').change((e) => {
        const dto = {
            eventName: $(e.target).val()
        }

        enableFormControls('#add-participant-form > div:nth-child(5)',
                           '#add-participant-form > div:nth-child(6)');

        invertButtonDiability(document.getElementById("js-add-participant-button"), false);
        // service
        $.ajax({
            url: "/api/CategoriesApi",
            data: dto,
            dataType: 'json',
            method: "POST",
            success: done,
            fail: () => {
                alert("sdfd");
            }           
        });
    });

    $('input[type="radio"]').change((e) => {
        dropDown.empty();
        console.log(e.currentTarget.value);
        e.currentTarget.value === 'Female' ? generateGenderDropDown(femaleCategories) : generateGenderDropDown(maleCategories);
    });

    $('#render-payment-form').on('click', (e) => {
        const button = $(e.target);
        const participantId = button.attr("data-participant");
    });


});