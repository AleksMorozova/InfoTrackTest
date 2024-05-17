import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.html',
  styleUrls: ['../app.component.css']
})

export class MenuComponent {
  title = 'nav';

  constructor(private router: Router,
    private route: ActivatedRoute) {
  }

  public search(): void {
    this.router.navigate(['search'], { relativeTo: this.route });
  }

  public history(): void {
    this.router.navigate(['history'], { relativeTo: this.route });
  }

  public favorite(): void {
    this.router.navigate(['favorite'], { relativeTo: this.route });
  }

  public about(): void {
    this.router.navigate(['about'], { relativeTo: this.route });
  }
}
