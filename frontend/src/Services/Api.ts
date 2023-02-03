import { CreateContact } from "./../Interfaces/CreateContact";
import axios, { Axios, AxiosResponse } from "axios";
import { Contact } from "../Interfaces/Contact";

// Use axios to make API calls and make the baseUrl to localhost:5000
const api = axios.create({
  baseURL: "http://localhost:5000/api",
});

// Get all the contacts from the API
export const getAllContacts = async (): Promise<Contact[]> => {
  let contacts = await api.get<Contact[]>(`/contacts`);
  return contacts.data;
};

// Get a single contact from the API
export const getContact = async (id: string): Promise<Contact> => {
  let response = await api.get(`/contacts/${id}`);
  return response.data;
};

// Add a new contact to the API
export const addContact = async (contact: CreateContact): Promise<Contact> => {
  let response = await api.post(`/contacts`, contact);
  return response.data;
};

// Delete a contact from the API
export const deleteContact = async (id: string): Promise<void> => {
  await api.delete(`/contacts/${id}`);
};

// Update a contact in the API
export const updateContact = async (contact: Contact): Promise<Contact> => {
  let response = await api.put(`/contacts/${contact.id}`, contact);
  return response.data;
};
