import { Component, OnInit } from "@angular/core";
import { DataService } from '../../../services/data.service';
import { IPagedResults } from '../../../shared/IPagedResults';
import { IProject } from '../../../model/project-interface';


@Component({
    templateUrl:'./projects-list.component.html'
})
export class ProjectsListComponent implements OnInit {

    totalRecords: number = 0;
    pageSize: number = 10;
    projects: IProject[] = [];

    ngOnInit() {
        this.getProjectsPage(1);
    }

    constructor(private dataService: DataService) { }

    getProjectsPage(page: number) {
        this.dataService.getProjectsPage((page - 1) * this.pageSize, this.pageSize)
            .subscribe((response: IPagedResults<IProject[]>) => {
                this.projects = response.results;
                this.totalRecords = response.totalRecords;
            },
            (err: any) => console.log(err),
            () => console.log('getCustomersPage() retrieved customers'));
    }
    
}