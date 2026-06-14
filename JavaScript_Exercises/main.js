// A simple helper to mirror console logs to the UI for demonstration purposes
function logToUI(message) {
    const debugContainer = document.getElementById('debugContainer');
    if (debugContainer) {
        const msgElement = document.createElement('div');
        msgElement.textContent = message;
        debugContainer.appendChild(msgElement);
        debugContainer.scrollTop = debugContainer.scrollHeight;
    }
    console.log(message);
}

// 1. JavaScript Basics & Setup
// Use <script src="main.js"></script> in HTML (done)
// Log "Welcome to the Community Portal" using console.log()
logToUI("Welcome to the Community Portal");

window.addEventListener('load', () => {
    // Use an alert to notify when the page is fully loaded
    alert("Welcome to the Community Portal! The page is fully loaded.");
    logToUI("Page fully loaded alert shown.");
});

// 2. Syntax, Data Types, and Operators
// Use const for event name and date, let for seats
const eventName = "Community Picnic";
const eventDate = "2026-07-01";
let seats = 50;

// Concatenate event info using template literals
const eventInfo = `Join us for the ${eventName} on ${eventDate}. Seats available: ${seats}`;
logToUI(eventInfo);

// Use ++ or -- to manage seat count on registration
seats--;
logToUI(`One seat booked for ${eventName}. Remaining seats: ${seats}`);

// 5. Objects and Prototypes
// Define Event constructor or class
class CommunityEvent {
    constructor(id, name, date, category, availableSeats, isPast = false) {
        this.id = id;
        this.name = name;
        this.date = date;
        this.category = category;
        this.availableSeats = availableSeats;
        this.isPast = isPast;
    }

    // Add checkAvailability() to prototype
    checkAvailability() {
        return this.availableSeats > 0 && !this.isPast;
    }
}

const sampleEvent = new CommunityEvent(99, "Prototype Test Event", "2026-10-01", "Music", 10);
// List object keys and values using Object.entries()
logToUI("Object.entries() Output:");
Object.entries(sampleEvent).forEach(([key, value]) => {
    logToUI(`- ${key}: ${value}`);
});

// 6. Arrays and Methods
// Manage an array of all community events
let eventsList = [
    new CommunityEvent(1, "Local Concert", "2026-06-20", "Music", 50),
    new CommunityEvent(2, "Pottery Workshop", "2026-06-25", "Workshop", 15),
    new CommunityEvent(3, "Basketball Tournament", "2026-07-05", "Sports", 0), // Full event
    new CommunityEvent(4, "Past Bake Sale", "2026-01-10", "Food", 20, true) // Past event
];

// Add new events using .push()
eventsList.push(new CommunityEvent(5, "Jazz Night", "2026-07-10", "Music", 30));

// Use .filter() to show only music events
const musicEvents = eventsList.filter(event => event.category === "Music");
logToUI(`Music Events Count: ${musicEvents.length}`);

// Use .map() to format display cards (e.g., "Workshop on Baking")
const formattedEvents = eventsList.map(event => `${event.category} Event: ${event.name}`);
logToUI(`Formatted Events: ${formattedEvents.join(' | ')}`);

// 4. Functions, Scope, Closures, Higher-Order Functions
// Create addEvent()
function addEvent(name, date, category, seats) {
    const newId = eventsList.length ? Math.max(...eventsList.map(e => e.id)) + 1 : 1;
    eventsList.push(new CommunityEvent(newId, name, date, category, seats));
    renderEvents();
}

// Use closure to track total registrations for a category
function createCategoryTracker() {
    const categoryCounts = {};
    return function(category) {
        if (!categoryCounts[category]) {
            categoryCounts[category] = 0;
        }
        categoryCounts[category]++;
        return categoryCounts[category];
    };
}
const trackRegistration = createCategoryTracker();

// Pass callbacks to filter functions for dynamic search
function filterEvents(events, callback) {
    return events.filter(callback);
}

// 10. Modern JavaScript Features
// Use let, const, default parameters in functions
function filterEventsByCategory(category = "All") {
    // Use spread operator to clone event list before filtering
    const clonedEvents = [...eventsList];
    if (category === "All") return clonedEvents;
    
    return filterEvents(clonedEvents, event => {
        // Use destructuring to extract event details
        const { category: eventCategory } = event;
        return eventCategory === category;
    });
}

// 7. DOM Manipulation
// Access DOM elements using querySelector()
const eventsContainer = document.querySelector('#eventsContainer');
const eventSelect = document.querySelector('#eventSelect');
const categoryFilter = document.querySelector('#categoryFilter');
const searchInput = document.querySelector('#searchInput');

function renderEvents(eventsToRender = eventsList) {
    eventsContainer.innerHTML = '';
    
    const currentSelect = eventSelect.value;
    eventSelect.innerHTML = '<option value="">--Select an Event--</option>';

    // 3. Conditionals, Loops, and Error Handling
    // Loop through the event list and display using forEach()
    eventsToRender.forEach(event => {
        // Use if-else to hide past or full events
        if (event.isPast || event.availableSeats === 0) {
            // Hide (don't render)
        } else {
            // Create and append event cards using createElement()
            const card = document.createElement('div');
            card.className = 'event-card';
            card.innerHTML = `
                <h3>${event.name}</h3>
                <p>Date: ${event.date}</p>
                <p>Category: ${event.category}</p>
                <p>Available Seats: <span id="seats-${event.id}">${event.availableSeats}</span></p>
                <!-- 8. Event Handling: Use onclick for "Register" buttons -->
                <button class="register-card-btn" onclick="openRegisterForm(${event.id})">Register Here</button>
                <button class="cancel-btn" data-id="${event.id}">Cancel Registration</button>
            `;
            eventsContainer.appendChild(card);

            const option = document.createElement('option');
            option.value = event.id;
            option.textContent = `${event.name} (${event.availableSeats} seats left)`;
            eventSelect.appendChild(option);
        }
    });

    if (currentSelect && eventSelect.querySelector(`option[value="${currentSelect}"]`)) {
        eventSelect.value = currentSelect;
    }
}

// 8. Event Handling
window.openRegisterForm = function(eventId) {
    eventSelect.value = eventId;
    document.querySelector('#registration-section').scrollIntoView({ behavior: 'smooth' });
};

// Use onchange to filter events by category
categoryFilter.onchange = function(e) {
    const selectedCategory = e.target.value;
    const filtered = filterEventsByCategory(selectedCategory);
    renderEvents(filtered);
};

// Use keydown to allow quick search by name
searchInput.addEventListener('keydown', function(e) {
    setTimeout(() => {
        const query = e.target.value.toLowerCase();
        const searchResults = filterEvents([...eventsList], event => event.name.toLowerCase().includes(query));
        renderEvents(searchResults);
    }, 0);
});

// Update UI when user cancels registration
eventsContainer.addEventListener('click', function(e) {
    if (e.target.classList.contains('cancel-btn')) {
        const eventId = parseInt(e.target.getAttribute('data-id'));
        const eventIndex = eventsList.findIndex(ev => ev.id === eventId);
        if (eventIndex > -1) {
            eventsList[eventIndex].availableSeats++;
            renderEvents(filterEventsByCategory(categoryFilter.value)); // Update UI
            logToUI(`Cancelled registration for Event ID: ${eventId}. Seats increased.`);
        }
    }
});


// 9. Async JS, Promises, Async/Await
// Fetch event data from a mock JSON endpoint using .then() and .catch()
function fetchMockDataWithPromises() {
    logToUI("Fetching with Promises...");
    fetch('https://jsonplaceholder.typicode.com/posts?_limit=1')
        .then(response => response.json())
        .then(data => {
            logToUI(`Promise Fetch Results length: ${data.length}`);
        })
        .catch(error => {
            console.error("Error fetching data:", error);
        });
}

// Rewrite using async/await and show loading spinner
async function fetchRemoteEvents() {
    const spinner = document.querySelector('#loadingSpinner');
    spinner.style.display = 'inline';
    
    try {
        const response = await fetch('https://jsonplaceholder.typicode.com/users');
        if (!response.ok) throw new Error("Network response was not ok");
        const data = await response.json();
        
        // Add one mock remote event
        if (data && data.length > 0) {
            addEvent(`Tech Meetup by ${data[0].name}`, "2026-09-01", "Workshop", 40);
            logToUI("Remote events fetched and added via async/await.");
        }
    } catch (error) {
        console.error("Async/Await Fetch Error:", error);
    } finally {
        spinner.style.display = 'none';
    }
}

// 11. Working with Forms & 12. AJAX & Fetch API
const registrationForm = document.querySelector('#registrationForm');
const formMessage = document.querySelector('#formMessage');

// Create registerUser function as requested in Task 4
async function registerUser(name, email, eventId) {
    // 3. Conditionals, Loops, and Error Handling: Wrap registration logic in try-catch to handle errors
    try {
        const selectedEvent = eventsList.find(e => e.id == eventId);
        if (!selectedEvent || selectedEvent.availableSeats <= 0) {
            throw new Error("Event is fully booked or invalid.");
        }

        formMessage.textContent = "Submitting registration...";
        formMessage.style.color = "blue";

        // 13. Debugging and Testing
        // Add breakpoints and inspect variables here
        // Log form submission steps and check fetch request payload
        logToUI(`[Debug] Attempting to register ${name} (${email}) for Event ID ${eventId}`);
        const payload = { name, email, eventId };
        logToUI(`[Debug] POST Request Payload: ${JSON.stringify(payload)}`);

        // 12. AJAX & Fetch API: Use fetch() to POST user data to a mock API
        const response = await fetch('https://jsonplaceholder.typicode.com/posts', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        });

        if (!response.ok) throw new Error("Server rejected the registration.");

        const responseData = await response.json();
        logToUI(`[Debug] Server Response: ID ${responseData.id}`);
        
        // 12. Use setTimeout() to simulate a delayed response
        setTimeout(() => {
            // Success
            selectedEvent.availableSeats--;
            // Update UI when user registers
            renderEvents(filterEventsByCategory(categoryFilter.value)); 
            
            const count = trackRegistration(selectedEvent.category);
            logToUI(`Total registrations for category '${selectedEvent.category}': ${count}`);
            
            // Show success message
            formMessage.textContent = `Success! You are registered. Confirmation ID: ${responseData.id}`;
            formMessage.style.color = "green";
            registrationForm.reset();
        }, 1500);

    } catch (error) {
        logToUI(`[Debug] Registration Error: ${error.message}`);
        // Show failure message
        formMessage.textContent = error.message;
        formMessage.style.color = "red";
    }
}

registrationForm.addEventListener('submit', function(event) {
    // Prevent default form behavior using event.preventDefault()
    event.preventDefault();
    
    // Capture name, email, and selected event using form.elements
    const elements = registrationForm.elements;
    const name = elements['name'].value.trim();
    const email = elements['email'].value.trim();
    const eventId = elements['eventSelect'].value;

    let hasError = false;
    
    // Validate inputs and show errors inline
    if (!name) {
        document.querySelector('#nameError').textContent = "Name is required.";
        hasError = true;
    } else {
        document.querySelector('#nameError').textContent = "";
    }

    if (!email || !email.includes('@')) {
        document.querySelector('#emailError').textContent = "Valid email is required.";
        hasError = true;
    } else {
        document.querySelector('#emailError').textContent = "";
    }

    if (!eventId) {
        document.querySelector('#eventSelectError').textContent = "Please select an event.";
        hasError = true;
    } else {
        document.querySelector('#eventSelectError').textContent = "";
    }

    if (hasError) return;

    registerUser(name, email, eventId);
});

// 14. jQuery and JS Frameworks
$(document).ready(function() {
    // Use $('#registerBtn').click(...) to handle click events
    $('#registerBtn').click(function() {
        // Use .fadeIn() and .fadeOut() for event cards
        $('.event-card').fadeOut(500, function() {
            $(this).fadeIn(500);
        });
        logToUI("jQuery click event fired: Cards faded out and in.");
    });

    /*
      Benefit of moving to frameworks like React or Vue:
      React and Vue use a Virtual DOM which allows for declarative UI development.
      Instead of manually updating the DOM with querySelector and innerHTML 
      (which can be error-prone and hard to maintain as apps grow), 
      frameworks automatically sync the UI with application state efficiently.
    */
});

// Initialize App
fetchMockDataWithPromises();
fetchRemoteEvents().then(() => {
    renderEvents();
});
