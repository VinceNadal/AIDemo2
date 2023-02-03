import React, { useState } from "react";
import { Contact } from "../Interfaces/Contact";
import { addContact } from "../Services/Api";

interface Props {
  handleAddContact: (contact: Contact) => void;
}

export default function ContactForm({ handleAddContact }: Props) {
  // create a state variable for the form inputs
  const [contact, setContact] = useState({
    firstName: "",
    lastName: "",
    physicalAddress: "",
    deliveryAddress: "",
  });

  // create a function to handle the form submission
  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    console.log(contact);
    const addedContact = await addContact(contact);
    handleAddContact(addedContact);
  };

  // create a function to handle the form input changes
  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setContact((prevContact) => {
      return {
        ...prevContact,
        [name]: value,
      };
    });
  };

  return (
    <form onSubmit={handleSubmit}>
      <label htmlFor="firstName">First Name</label>
      <input
        type="text"
        id="firstName"
        name="firstName"
        value={contact.firstName}
        onChange={handleChange}
      />

      <label htmlFor="lastName">Last Name</label>
      <input
        type="text"
        id="lastName"
        name="lastName"
        value={contact.lastName}
        onChange={handleChange}
      />

      <label htmlFor="physicalAddress">Physical Address</label>
      <input
        type="text"
        id="physicalAddress"
        name="physicalAddress"
        value={contact.physicalAddress}
        onChange={handleChange}
      />

      <label htmlFor="deliveryAddress">Delivery Address</label>
      <input
        type="text"
        id="deliveryAddress"
        name="deliveryAddress"
        value={contact.deliveryAddress}
        onChange={handleChange}
      />
      <button type="submit">Submit</button>
    </form>
  );
}
