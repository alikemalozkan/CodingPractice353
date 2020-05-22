package com.example.DatabaseProject;

import javax.persistence.Entity;
import javax.persistence.Table;
import org.springframework.lang.NonNull;
import javax.persistence.Id;
import javax.persistence.Column;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;


@Entity
@Table(name="publishers")
public class Publisher {
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	@Column(name="publisher_id")
	@NonNull
	private int id;
	
	@Column(name="publisher_name", length=50, nullable=false, unique=false)
	private String name;
	
	public Publisher() {}
	
	public int getId() {
		return id;
	}
	public String getName() {
		return name;
	}
	public void setName(String publisher_name) {
		this.name = publisher_name;
	} 
	
	
}
