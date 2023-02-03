import React from 'react';
import { Contact } from '../Interfaces/Contact';

interface Props {
    contacts: Contact[];
}

export default function ContactList({ contacts }: Props) {
    //Create contact list component that will display all contacts using ul and li tags
    return (
        <>
            <h2>Contact List</h2>
            <ul>
                {contacts.map((contact) => (
                    <li key={contact.id}>
                        {contact.firstName} {contact.lastName} {contact.physicalAddress} {contact.deliveryAddress}
                    </li>
                ))}
            </ul>
        </>
        
    );

}