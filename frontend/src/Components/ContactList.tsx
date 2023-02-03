import React, { useEffect } from "react";
import { Contact } from "../Interfaces/Contact";
import { getAllContacts } from "../Services/Api";

interface Props {
  contacts: Contact[];
  handleSetContacts: (contacts: Contact[]) => void;
}

export default function ContactList({ contacts, handleSetContacts }: Props) {
  // call getContacts function from Api.tsx to get all contacts and use useEffect to call it only once
  useEffect(() => {
    const callGetAllContacts = async () => {
      handleSetContacts(await getAllContacts());
    };
    callGetAllContacts();
  }, []);

  //Create contact list component that will display all contacts using ul and li tags
  return (
    <>
      <h2>Contact List</h2>
      <ul>
        {contacts.map((contact) => (
          <li key={contact.id}>
            {contact.firstName} {contact.lastName} {contact.physicalAddress}{" "}
            {contact.deliveryAddress}
          </li>
        ))}
      </ul>
    </>
  );
}
