package com.example.DatabaseProject;

import javax.persistence.Entity;
import javax.persistence.Table;

import org.springframework.lang.NonNull;

import javax.persistence.Id;
import javax.persistence.Column;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;

@Entity
@Table(name="books")
public class Book{
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	@Column(name="book_id")
	@NonNull
	private int id;
	
	@Column(name="publisher_id")
	private int publisher_id;
	
	@Column(name="author_id" )
	private int author_id;
	
	@Column(name="page_number" )
	private int page_number;
	
	@Column(name="book_title" )
	private String book_title;
	
	@Column(name="status")
	private String status;
	
	@Column(name="type")
	private String type;
	
	public Book(){}

	public int getPublisher_id() {
		return publisher_id;
	}

	public void setPublisher_id(int publisher_id) {
		this.publisher_id = publisher_id;
	}

	public int getAuthor_id() {
		return author_id;
	}

	public void setAuthor_id(int author_id) {
		this.author_id = author_id;
	}

	public int getPage_number() {
		return page_number;
	}

	public void setPage_number(int page_number) {
		this.page_number = page_number;
	}

	public String getBook_title() {
		return book_title;
	}

	public void setBook_title(String book_title) {
		this.book_title = book_title;
	}

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}
	
}
