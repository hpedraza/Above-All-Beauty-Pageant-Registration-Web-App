$(document).ready(function () {
    let dropDown = $("select#age-group-dropdown");
    let dateInput = $('#add-participant-form > div > input[type="date"]');
    let gender = 'male';

    let maleCategories = [];
    let femaleCategories = [];

    let button;
    let id;
    let dob;
    let years;
    let months;
    let categoryName;


    const enableFormControls = (...divs) => {
        $(divs.join()).css('display', 'block');
    }

    // add category to male list or female list
    const addToOneofTheCategories = (group, isParticipantFemale) => {
        isParticipantFemale ? femaleCategories.push(group) : maleCategories.push(group);
    }

    const generateGenderDropDown = (genderGroups) => { 
        let html = '';
        for (let group of genderGroups) {
            html += `<option value="${group.value}">${group.group}</option>`;
        }
        dropDown.html(html);
    }

    const isFemale = (group) => {
        const words = group.split(" ");
        const lastWord = words[words.length - 1];
        if (lastWord === "Miss") {
            gender = "female";
            return true;
        } else {
            gender = 'male';
            return false;
        }
    
    }

    const disableFormControls = (...divs) => {
        $(divs.join()).css('display', 'none');
    }

    const invertButtonDisability = (button , disable) => {
        disable ? button.disabled = true : button.disabled = false;
    }

    // when categories have been fetched - split them into malecategory array and femalecategory array.
    const done = (categories) => {
        console.log(JSON.parse(categories));
        for (let group of JSON.parse(categories)) {
            addToOneofTheCategories(group, isFemale(group.group));
        }

        dateInput.val() ? FilterDropDown(years) : null;
    }

    
    // when event has been changed - fetch event's categories
    $('select#event-drop-down-list.form-control').change((e) => {
        const dto = {
            eventName: $(e.target).val()
        }

        enableFormControls('#add-participant-form > div:nth-child(11)',
                           '#add-participant-form > div:nth-child(12)');

        invertButtonDisability(document.getElementById("js-add-participant-button"), false);
        // service
        $.ajax({
            url: "/api/CategoriesApi",
            data: dto,
            dataType: 'json',
            method: "POST",
            success: done,
            fail: () => {
                alert("Something failed.");
            }           
        });
    });

    // When gender is changed show appropriate categories participant can join
    $('input[type="radio"]').change((e) => {
        dropDown.empty();
        e.currentTarget.value === "Female" ? gender = "female" : gender = "male";
        dateInput.val() ? FilterDropDown(years) : null;
    });
 
    // remove participant -- ask if they are sure to delete //
    const removeParticipant = () => {
        button.parent().parent().parent().remove();
    }

    $('table > tbody > tr > td > form > #js-remove-participant').on('click', (e) => {
        button = $(e.target);
        id = button.attr('data-participant');
        $('#remove-participant').modal('show');
    });

    // Modal button has been confirmed to delete participant
    $('#remove-participant > div > div > div > #remove-participant-button').on('click', () => {
        DeleteParticipant(id);
    })


    //service
    const DeleteParticipant = (id) =>
    {
        $.ajax({
            url: "/api/Participant/" + id,
            method: "Delete"
        }).done(removeParticipant)
          .fail(() => { alert("Could not remove participant. Please contact administrator.") });
    }


    //-- Client side business logic --//
    // when birthdate has been inserted check for categories participant can join and filter out the rest from drop down
    $(dateInput).on('focusout', () => {
        let dob = new Date($('#add-participant-form > div > input[type="date"]')[0].value);
        let time = Date.now() - dob.getTime();
        let date = new Date(time);

        years = Math.abs(date.getUTCFullYear() - 1970);

        FilterDropDown(years);    
    })


    const FilterDropDown = (year) => {
        if (gender === "male") {
            if (year === 0) {
                categoryName = "Baby Mr.";
            } else if (year === 1) {
                categoryName = "Pee Wee Mr.";
            } else if (year === 2 || year === 3) {
                categoryName = "Tiny Mr.";
            } else if (year === 4 || year === 5 ) {
                categoryName = "Little Mr.";
            } else {
                categoryName = '';
            }
        } else {
            if (year === 0) {
                categoryName = "Baby Miss";
            } else if (year === 1) {
                categoryName = "Pee Wee Miss";
            } else if (year === 2 || year === 3) {
                categoryName = "Tiny Miss";
            } else if (year === 4 || year === 5) {
                categoryName = "Little Miss";
            } else if (year === 6 || year === 7 || year === 8) {
                categoryName = "Petite Miss";
            } else if (year === 9 || year === 10 || year === 11 || year === 12) {
                categoryName = "Youth Miss";
            } else if (year === 13 || year === 14 || year === 15) {
                categoryName = "Teen Miss";
            } else {
                categoryName = '';
            }
        }
        Filter();
    }

    const Filter = () => {
        dropDown.empty();
        console.log(femaleCategories);
        console.log(categoryName);
        let obj = gender === "male" ? maleCategories.find(findGroup) : femaleCategories.find(findGroup);
        console.log(obj);

        typeof obj === 'undefined' ? dropDown.html(`<option disabled selected value>-- Participant is too old --</option>`) : dropDown.html(`<option value="${obj.value}">${obj.group}</option>`);

    }

    const make = () => { }
    const findGroup = (group) => {
        return group.group === categoryName;
    }
});