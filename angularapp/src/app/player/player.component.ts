import { Component, OnInit } from '@angular/core';
import { Player } from 'src/models/player.model';
@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {


  players : Player[]
  newPlayer : Player

  constructor() { }

  ngOnInit(): void {
  }

}
