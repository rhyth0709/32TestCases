import { Component, OnInit } from '@angular/core';
import { Team } from 'src/models/team.model';
import { AdminService } from '../services/admin.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-delete-team',
  templateUrl: './delete-team.component.html',
  styleUrls: ['./delete-team.component.css']
})
export class DeleteTeamComponent implements OnInit {

  teamData : Team
  id:number

  constructor(private as :AdminService,private ar :ActivatedRoute,private router:Router) { 

  }


  ngOnInit(): void {

    const tid = this.ar.snapshot.paramMap.get('id')
    this.id = Number(tid)
    this.getTeam(this.id)
  }

  saveData():void{

    this.as.DeletePlayer(this.id).subscribe(()=>{
      alert("Deleted Successfully")
      this.router.navigate(['/listteam'])
    })
  }

  getTeam(id:number){
    this.as.getTeam(this.id).subscribe((data:Team)=>{
      this.teamData = data
    })
  }

}
