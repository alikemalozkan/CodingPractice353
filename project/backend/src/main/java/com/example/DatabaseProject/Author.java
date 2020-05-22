package com.example.DatabaseProject;

import javax.persistence.Entity;
import javax.persistence.Table;

import org.springframework.lang.NonNull;

import javax.persistence.Id;
import javax.persistence.Column;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;

@Entity
@Table(name="authors")
public class Author {
	
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	@Column(name="author_id")
	@NonNull
	private Integer id;
	
	@Column(name="author_name", length=50, nullable=false, unique=false)
	private String name;
	
	@Column(name="author_surname", length=50, nullable=false, unique=false)
	private String surname;
	
	public Integer getId() {
		return id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getSurname() {
		return surname;
	}
	public void setSurname(String surname) {
		this.surname = surname;
	}
	
}
