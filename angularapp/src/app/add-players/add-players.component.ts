import { Component, OnInit } from '@angular/core';
import { PlayerService } from '../services/player.service';
import { Player } from '../models/player.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-add-players',
  templateUrl: './add-players.component.html',
  styleUrls: ['./add-players.component.css']
})
export class AddPlayersComponent implements OnInit {
  

  playerData :Player = {id:0,name:'',age:0,teamID:0,category:'',biddingPrice:0}


  constructor(private ms :PlayerService,private router:Router) { }

  onSave(player:Player):void{

    this.playerData = player
    this.ms.AddPlayer(this.playerData).subscribe(()=>{
      alert("Record Added Successfully")
  //  this.router.navigate(['/listmovies'])
    })
  }


  ngOnInit(): void {
  }

}
