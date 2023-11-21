import { Component, OnInit } from '@angular/core';
import { Player } from 'src/models/player.model';
import { AdminService } from '../services/admin.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css']
})
export class EditPlayerComponent implements OnInit {

  id:number
  playerdata :{id:number,name:string,age:number,category:string,biddingPrice:number}
  constructor(private as : AdminService,private ar:ActivatedRoute) {

    const tid = this.ar.snapshot.paramMap.get('id')
    this.id = Number(tid)
    this.getPlayer(this.id)

   }

   getPlayer(id :number){
    this.as.getPlayer(id).subscribe((data)=>{
      this.playerdata = data;

    })

   }

   onSave(player:Player){

    this.playerdata = player
    this.as.EditPlayer(this.playerdata).subscribe(()=>{
      alert("Record Edited successfully")
    })
   }


  ngOnInit(): void {
  }

}
