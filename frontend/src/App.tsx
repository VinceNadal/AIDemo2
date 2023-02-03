import React, { useState } from "react";
import ContactForm from "./Components/ContactForm";
import ContactList from "./Components/ContactList";
import { Contact } from "./Interfaces/Contact";

function App() {
  // create a state variable for the contacts
  const [contacts, setContacts] = useState<Contact[]>([]);

  // create a handler to add a new contact
  const addContactHandler = (contact: Contact) => {
    setContacts((prevContacts) => {
      return [...prevContacts, contact];
    });
  };

  // create a handler to get all contacts
  const setContactsHandler = (contacts: Contact[]) => {
    setContacts(contacts);
  };

  return (
    <div className="App">
      <h1>Contacts Management System</h1>
      <ContactForm handleAddContact={addContactHandler} />
      <ContactList contacts={contacts} handleSetContacts={setContactsHandler} />
    </div>
  );
}

export default App;

// 2 Primary React Components
// ContactForm Component
// ContactList Component
